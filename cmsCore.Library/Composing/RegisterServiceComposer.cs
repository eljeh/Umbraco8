using cmsCore.Library.Services;
using Umbraco.Core;
using Umbraco.Core.Composing;

namespace cmsCore.Library.Composing
{
    [RuntimeLevel(MinLevel = RuntimeLevel.Run)]
    public class RegisterServiceComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            composition.Register<ISearchService, SearchService>(Lifetime.Request);
            composition.Register(typeof(IDataTypeValueService), typeof(DataTypeValueService), Lifetime.Request);
        }
    }
}
