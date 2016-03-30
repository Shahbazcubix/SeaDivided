using UnityEngine;
using System.Collections;

public class FuzzySet_LeftShoulder : FuzzySet {

	//the values that define the shape of this FLV
	private double m_dPeakPoint;
	private double m_dRightOffset;
	private double m_dLeftOffset;
	
	public FuzzySet_LeftShoulder(double peak,
	                             double LeftOffset,
	                             double RightOffset) : base(((peak - LeftOffset) + peak) / 2) {
		

		m_dPeakPoint = peak;
		m_dLeftOffset = LeftOffset;
		m_dRightOffset = RightOffset;
	}


	public override double CalculateDOM(double val) {
		//test for the case where the left or right offsets are zero
		//(to prevent divide by zero errors below)
		if ((isEqual(m_dRightOffset, 0.0d) && (isEqual(m_dPeakPoint, val)))
		    || (isEqual(m_dLeftOffset, 0.0d) && (isEqual(m_dPeakPoint, val)))) {
			return 1.0d;
		} //find DOM if right of center
		else if ((val >= m_dPeakPoint) && (val < (m_dPeakPoint + m_dRightOffset))) {
			double grad = 1.0d / -m_dRightOffset;
			return grad * (val - m_dPeakPoint) + 1.0d;
		} //find DOM if left of center
		else if ((val < m_dPeakPoint) && (val >= m_dPeakPoint - m_dLeftOffset)) {
			return 1.0d;
		} //out of range of this FLV, return zero
		else {
			return 0.0d;
		}
		
	}

	public bool isEqual(double a, double b) {
		if (Mathf.Abs ((float)a - (float)b) < 0.000000000001d)
			return true;
		
		return false;
		
	}
}
