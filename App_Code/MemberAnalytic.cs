using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for MemberFeedback
/// </summary>
public class MemberAnalytic
{
    public Member Member { get; set; }
    public int NoOfPositiveFeedback { get; set; }
    public int NoOfNeutralFeedback { get; set; }
    public int NoOfNegativeFeedback { get; set; }
    public int NoOfRentalAsRentee { get; set; }
    public int NoOfRentalAsRenter { get; set; }

    public MemberAnalytic() { /* empty constructor */ }
   
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