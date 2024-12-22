
using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Reviews;

public static class ReviewErrors
{
    public static readonly Error NotEligible = new(
        "Review.NotEligible",
        "با توجه به عدم پایان اجاره، نظر قابل پذیرش نیست.");


    public static readonly Error Invalid = new(
        "Rating.Invalid", 
        "امتیاز قابل قبول نیست");

}