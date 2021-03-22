using System.ComponentModel.DataAnnotations;
using System.Reflection;
using Mapster;
using Rawpotion.Api.Domain;

namespace Rawpotion.Api.Mapping
{
    public class MappingRegister : ICodeGenerationRegister
    {
        public void Register(CodeGenerationConfig config)
        {
            config.AdaptTo(
                "[name]Dto",
                MapType.Map | MapType.Projection | MapType.MapToTarget)
                .ForType<User>(cfg => cfg.Ignore(it => it.PasswordHash))
                .ApplyDefaultRule();

            config.AdaptFrom("[name]Add", MapType.Map)
                .IgnoreAttributes(typeof(KeyAttribute))
                .ForType<User>(cfg => cfg.Map(u => u.PasswordHash, typeof(string), "Password"))
                .ApplyDefaultRule();

            config.AdaptFrom("[name]Update", MapType.MapToTarget)
                .IgnoreAttributes(typeof(KeyAttribute))
                .ForType<User>(cfg => cfg.Ignore(it => it.PasswordHash))
                .ApplyDefaultRule();

            config.GenerateMapper("[name]Mapper")
                .ForType<User>();
        }
    }

    public static class RegisterExtensions
    {
        public static AdaptAttributeBuilder ApplyDefaultRule(this AdaptAttributeBuilder builder) =>
            builder
                .ForAllTypesInNamespace(Assembly.GetExecutingAssembly(), "Rawpotion.Api.Domain")
                .ShallowCopyForSameType(true)
            ;
    }


}