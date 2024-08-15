using ExampleTests.Fakers;

namespace ExampleTests
{
    public class User_Tests
    {
        [Fact]
        public void Should_Pass_EmailValidation()
        {
            // Arrange
            var user = FakeUserData.GetFakeUser();
            var expected = true;

            // Act
            var actual = user.IsValidEmail();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Not_Pass_EmailValidation()
        {
            // Arrange
            var user = FakeUserData.GetFakeUser();
            var invalidEmail = user.Email.Replace("@", "");
            user.Email = invalidEmail;
            var expected = false;

            // Act
            var actual = user.IsValidEmail();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Pass_PasswordValidation()
        {
            // Arrange
            var user = FakeUserData.GetFakeUser();
            var expected = true;

            // Act
            var actual = user.IsValidPassword();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Not_Pass_PasswordValidation()
        {
            // Arrange
            var user = FakeUserData.GetFakeInvalidUserPassword();
            var expected = false;

            // Act
            var actual = user.IsValidPassword();

            // Assert
            Assert.Equal(expected, actual);
        }

        [Fact]
        public void Should_Validate_DateOfBirth()
        {
            // Arrange
            var user = FakeUserData.GetFakeUser();
            var expected = true;

            // Act
            var actual = user.IsValidDateOfBirth();

            // Assert
            Assert.Equal(expected, actual);
        }
    }
}