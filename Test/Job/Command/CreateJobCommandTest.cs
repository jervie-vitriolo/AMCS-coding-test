using Application;
using Application.Features.Job.Command.Create;
using FluentValidation.TestHelper;
using Microsoft.EntityFrameworkCore;
using Persistence;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory.Database;

namespace Test.Job.Command;

public class CreateJobCommandTest
{

    private readonly CreateJobCommandValidator _CreateJobCommandValidator = new();


    [Fact]
    public async Task Should_not_have_error_when_job_is_valid()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("amcsgroup")
            .Options;

        var context = new AppDbContext(options);
        var handler = new CreateJobCommandHandler(context);
        var request = new CreateJobCommand(DateTime.Now, DateTime.Now.AddMonths(3), 5000, "Crypto.com Arena Job", string.Empty);

        // Act
        var result = await _CreateJobCommandValidator.TestValidateAsync(request);

        // Assert
        result.ShouldNotHaveAnyValidationErrors();

    }
    [Fact]
    public async Task Should_have_error_when_job_buget_is_zero()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("amcsgroup")
            .Options;

        var context = new AppDbContext(options);
        var handler = new CreateJobCommandHandler(context);
        var request = new CreateJobCommand(DateTime.Now, DateTime.Now.AddMonths(3), 0, "Crypto.com Arena Job", string.Empty);

        // Act
        var result = await _CreateJobCommandValidator.TestValidateAsync(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.budget);
    }

    [Fact]
    public async Task Should_have_error_when_duedate_is_behind_startdate()
    {
        // Arrange
        var options = new DbContextOptionsBuilder<AppDbContext>()
            .UseInMemoryDatabase("amcsgroup")
            .Options;

        var context = new AppDbContext(options);
        var handler = new CreateJobCommandHandler(context);
        var request = new CreateJobCommand(DateTime.Now.AddMonths(3), DateTime.Now, 3500, "Crypto.com Arena Job", string.Empty);

        // Act
        var result = await _CreateJobCommandValidator.TestValidateAsync(request);

        // Assert
        result.ShouldHaveValidationErrorFor(x => x.duedate);
    }
}
