namespace ExxoAvalonOrigins.UI
{
    internal interface IElementListener
    {
        bool IsRecalculating { get; set; }
        void PostRecalculate();
    }
}
