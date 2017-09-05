using System.IO;
using NUnit.Framework;
using NzbDrone.Core.Download;
using NzbDrone.Core.Test.Framework;

namespace NzbDrone.Core.Test.Download
{
    [TestFixture]
    public class NzbValidationServiceFixture : CoreTest<NzbValidationService>
    {
        private byte[] GivenNzbFile(string name)
        {
            return File.ReadAllBytes(GetTestPath("Files/Nzbs/" + name + ".nzb"));
        }

        [Test]
        public void should_throw_on_invalid_nzb()
        {
            var filename = "NotNzb";
            var fileContent = GivenNzbFile(filename);

            Assert.Throws<InvalidNzbException>(() => Subject.Validate(filename, fileContent));
        }

        [Test]
        public void should_throw_when_no_files()
        {
            var filename = "NoFiles";
            var fileContent = GivenNzbFile(filename);

            Assert.Throws<InvalidNzbException>(() => Subject.Validate(filename, fileContent));
        }

        [Test]
        public void should_throw_when_no_groups_in_file()
        {
            var filename = "NoGroupInFile";
            var fileContent = GivenNzbFile(filename);

            Assert.Throws<InvalidNzbException>(() => Subject.Validate(filename, fileContent));
        }

        [Test]
        public void should_throw_when_no_group_in_groups()
        {
            var filename = "NoGroupInGroups";
            var fileContent = GivenNzbFile(filename);

            Assert.Throws<InvalidNzbException>(() => Subject.Validate(filename, fileContent));
        }

        [Test]
        public void should_throw_when_no_segments_in_file()
        {
            var filename = "NoSegmentsInFile";
            var fileContent = GivenNzbFile(filename);

            Assert.Throws<InvalidNzbException>(() => Subject.Validate(filename, fileContent));
        }

        [Test]
        public void should_throw_when_no_segment_in_segments()
        {
            var filename = "NoSegmentInSegments";
            var fileContent = GivenNzbFile(filename);

            Assert.Throws<InvalidNzbException>(() => Subject.Validate(filename, fileContent));
        }

        [Test]
        public void should_validate_nzb()
        {
            var filename = "ValidNzb";
            var fileContent = GivenNzbFile(filename);

            Subject.Validate(filename, fileContent);
        }
    }
}
