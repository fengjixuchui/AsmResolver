using AsmResolver.DotNet.Signatures.Types.Parsing;
using Xunit;

namespace AsmResolver.DotNet.Tests.Signatures
{
    public class TypeNameBuilderTest
    {
        private readonly ModuleDefinition _module;

        public TypeNameBuilderTest()
        {
            _module = new ModuleDefinition("DummyModule", KnownCorLibs.SystemPrivateCoreLib_v4_0_0_0);
        }

        [Fact]
        public void NameWithDotShouldBeEscaped()
        {
            var type = new TypeReference(_module, _module, "Company.ProductName", "Class.Name");
            string name = TypeNameBuilder.GetAssemblyQualifiedName(type.ToTypeSignature());
            Assert.Contains("Class\\.Name", name);
        }

        [Fact]
        public void NameWithEqualsShouldNotBeEscaped()
        {
            var type = new TypeReference(_module, _module, "Company.ProductName", "#=abc");
            string name = TypeNameBuilder.GetAssemblyQualifiedName(type.ToTypeSignature());
            Assert.DoesNotContain('\\', name);
            Assert.Contains("#=abc", name);
        }

        [Fact]
        public void NamespaceShouldNotBeEscaped()
        {
            var type = new TypeReference(_module, _module, "Company.ProductName", "ClassName");
            string name = TypeNameBuilder.GetAssemblyQualifiedName(type.ToTypeSignature());
            Assert.DoesNotContain('\\', name);
            Assert.Contains("Company.ProductName", name);
        }

        [Fact]
        public void NamespaceWithEqualsShouldNotBeEscaped()
        {
            var type = new TypeReference(_module, _module, "#=abc", "ClassName");
            string name = TypeNameBuilder.GetAssemblyQualifiedName(type.ToTypeSignature());
            Assert.DoesNotContain('\\', name);
            Assert.Contains("#=abc", name);
        }

        [Theory]
        [InlineData("MyNamespace", "MyType", "MyNestedType")]
        [InlineData("MyNamespace", "#=abc", "#=def")]
        public void NestedTypeShouldContainPlus(string ns, string name, string nestedType)
        {
            var type = new TypeReference(_module, new TypeReference(_module, ns, name), null, nestedType);
            string fullname = TypeNameBuilder.GetAssemblyQualifiedName(type.ToTypeSignature());
            Assert.DoesNotContain('\\', fullname);
            Assert.Contains($"{ns}.{name}+{nestedType}", fullname);
        }

        [Theory]
        [InlineData("MyType", "MyNestedType")]
        [InlineData("#=abc", "#=def")]
        public void NestedTypeNoNamespaceShouldContainPlus(string name, string nestedType)
        {
            var type = new TypeReference(_module, new TypeReference(_module, null, name), null, nestedType);
            string fullname = TypeNameBuilder.GetAssemblyQualifiedName(type.ToTypeSignature());
            Assert.DoesNotContain('\\', fullname);
            Assert.Contains($"{name}+{nestedType}", fullname);
        }
    }
}
