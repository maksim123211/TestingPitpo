using System.Collections.ObjectModel;

namespace MauiApp1.Areas
{
    public sealed class FaqBlock(IList<FaqArticle> list) : ReadOnlyCollection<FaqArticle>(list);

    public sealed record FaqArticle(string Question, string Answer);
}
