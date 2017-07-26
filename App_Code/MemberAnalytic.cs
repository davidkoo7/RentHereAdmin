using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


public class MemberAnalytic
{
    // propertise of MemberAnalytic
    public Member Member { get; set; }
    public int NoOfPositiveFeedback { get; set; }
    public int NoOfNeutralFeedback { get; set; }
    public int NoOfNegativeFeedback { get; set; }
    public int NoOfRentalAsRentee { get; set; }
    public int NoOfRentalAsRenter { get; set; }

    // empty MemberAnalytic constructor
    public MemberAnalytic() { }
   
    // constructor for MemberAnalytic
    public MemberAnalytic(Member mem, int noOfPositiveFeedback, int noOfNeutralFeedback, int noOfNegativeFeedback, int noOfRentalAsRentee, int noOfRentalAsRenter)
    {
        Member = mem;
        NoOfPositiveFeedback = noOfPositiveFeedback;
        NoOfNeutralFeedback = noOfNeutralFeedback;
        NoOfNegativeFeedback = noOfNegativeFeedback;
        NoOfRentalAsRentee = noOfRentalAsRentee;
        NoOfRentalAsRenter = noOfRentalAsRenter;
    }
}