using UnityEngine;
using System.Collections;

public class FuzzySet_RightShoulder : FuzzySet {



	//the values that define the shape of this FLV
	private double m_dPeakPoint;
	private double m_dLeftOffset;
	private double m_dRightOffset;
	
	public FuzzySet_RightShoulder(double peak,
	                              double LeftOffset,
	                              double RightOffset) : base(((peak + RightOffset) + peak) / 2) {
		

		m_dPeakPoint = peak;
		m_dLeftOffset = LeftOffset;
		m_dRightOffset = RightOffset;
		
	}

	/**
     * this method calculates the degree of membership for a particular value
     */

	public override double CalculateDOM(double val) {
		//test for the case where the left or right offsets are zero
		//(to prevent divide by zero errors below)
		if ((isEqual(m_dRightOffset, 0.0d) && (isEqual(m_dPeakPoint, val)))
		    || (isEqual(m_dLeftOffset, 0.0d) && (isEqual(m_dPeakPoint, val)))) {
			return 1.0d;
		} //find DOM if left of center
		else if ((val <= m_dPeakPoint) && (val > (m_dPeakPoint - m_dLeftOffset))) {
			double grad = 1.0d / m_dLeftOffset;
			
			return grad * (val - (m_dPeakPoint - m_dLeftOffset));
		} //find DOM if right of center and less than center + right offset
		else if ((val > m_dPeakPoint) && (val <= m_dPeakPoint + m_dRightOffset)) {
			return 1.0d;
		} else {
			return 0.0d;
		}
	}

	public bool isEqual(double a, double b) {
		if (Mathf.Abs ((float)a - (float)b) < 0.000000000001d)
			return true;
		
		return false;
		
	}
}
