using CourseStore.Framework.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CourseStore.Modules.Courses.Domain;
public class Course:AggregateRoot<long>
{
    public string Title { get; private set; }
    public string Description { get; private set; }
    public string Teacher { get; private set; }
    public DateTime StartDate { get; private set; }
    public int SessionCount { get; private set; }
    public int Price { get; private set; }

    internal Course()
    {

    }
    public Course(
        long id,
        string title,
        string description,
        string teacher,
        DateTime startDate,
        int sessionCount,
        int price)
    {
        Id = id;
        Title = title;
        Description = description;
        Teacher = teacher;
        StartDate = startDate;
        SessionCount = sessionCount;
        Price = price;
    }

    public static Course Create(
        long id,
        string title,
        string description,
        string teacher,
        DateTime startDate,
        int sessionCount,
        int price)
    {
        Course course = new(id, title, description, teacher, startDate, sessionCount, price);

        course.AddDomainEvent(new CourseCreatedDomainEvent(id, title, description, startDate, sessionCount, price));

        return course;

    }

    public Result ChangePrice(int newPrice)
    {
        Price = newPrice;

        AddDomainEvent(new CoursePriceChangedDomainEvent(Id, Price));

        return Result.Success();
    }

    public Result ChangeMetaData(string title, string description, DateTime startDate, int sessionCount)
    {
        Title = title;
        Description = description;
        StartDate = startDate;
        SessionCount = sessionCount;
        AddDomainEvent(new CourseMetaDataChangedDomainEvent(Id, Title, Description, StartDate, SessionCount));
        return Result.Success();
    }
}
