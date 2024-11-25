using HouseRent.Core.Domain.Framework;

namespace HouseRent.Core.Domain.Bookings;

public static class BookingErrors
{
    public static Error NotFound = new(
        "Booking.Found",
        "اجاره ای با شناسه ارسال شده یافت نشد");


    public static Error NotReserved = new(
        "Booking.NotReserved",
        "فقط اجاره های در حالت انتظار قابلیت تایید دارند");

    public static Error NotConfirmed = new(
        "Booking.NotReserved",
        "فقط اجاره های در حالت تایید این قابلیت را دارند");

    public static Error AlreadyStarted = new(
        "Booking.AlreadyStarted",
        "اجاره خانه در حال حاضر شروع شده است");
}