using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Terraria;
using Terraria.Graphics;
using Terraria.UI;

namespace ExxoAvalonOrigins.UI.Herbology;

internal class HerbologyUIStats : ExxoUIPanelWrapper<ExxoUIList>
{
    public readonly ExxoUITextPanel RankTitleText;
    public readonly ExxoUITextPanel HerbTierText;
    public readonly ExxoUIPanelWrapper<ExxoUIList> HerbTotalContainer;
    private readonly ExxoUIImage herbTotalIcon;
    private readonly ExxoUIText herbTotalText;
    public readonly ExxoUIPanelWrapper<ExxoUIList> PotionTotalContainer;
    private readonly ExxoUIImage potionTotalIcon;
    private readonly ExxoUIText potionTotalText;
    public HerbologyUIStats() : base(new ExxoUIList())
    {
        FitMinToInnerElement = true;
        Height.Set(0, 1);

        InnerElement.FitWidthToContent = true;
        InnerElement.Justification = Justification.Center;
        InnerElement.ContentHAlign = UIAlign.Center;

        RankTitleText = new ExxoUITextPanel(new ExxoUIText("")
        {
            TextColor = Color.Gold
        });
        InnerElement.Append(RankTitleText);

        HerbTierText = new ExxoUITextPanel(new ExxoUIText(""));
        InnerElement.Append(HerbTierText);

        HerbTotalContainer = new ExxoUIPanelWrapper<ExxoUIList>(new ExxoUIList())
        {
            FitMinToInnerElement = true,
            Tooltip = "Herb credits",
        };
        HerbTotalContainer.InnerElement.Direction = Direction.Horizontal;
        HerbTotalContainer.InnerElement.FitHeightToContent = true;
        HerbTotalContainer.InnerElement.FitWidthToContent = true;
        HerbTotalContainer.InnerElement.ContentVAlign = UIAlign.Center;
        InnerElement.Append(HerbTotalContainer);

        herbTotalIcon = new ExxoUIImage(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Images/UI/WorldCreation/IconRandomSeed"))
        {
            Inset = new Vector2(7, 7)
        };
        HerbTotalContainer.InnerElement.Append(herbTotalIcon);

        herbTotalText = new ExxoUIText("");
        HerbTotalContainer.InnerElement.Append(herbTotalText);

        PotionTotalContainer = new ExxoUIPanelWrapper<ExxoUIList>(new ExxoUIList())
        {
            FitMinToInnerElement = true,
            Tooltip = "Potion credits",
        };
        PotionTotalContainer.InnerElement.Direction = Direction.Horizontal;
        PotionTotalContainer.InnerElement.FitHeightToContent = true;
        PotionTotalContainer.InnerElement.FitWidthToContent = true;
        PotionTotalContainer.InnerElement.ContentVAlign = UIAlign.Center;
        InnerElement.Append(PotionTotalContainer);

        potionTotalIcon = new ExxoUIImage(ExxoAvalonOrigins.Mod.Assets.Request<Texture2D>("Images/UI/WorldCreation/IconEvilCorruption"))
        {
            Inset = new Vector2(4, 5)
        };
        PotionTotalContainer.InnerElement.Append(potionTotalIcon);

        potionTotalText = new ExxoUIText("");
        PotionTotalContainer.InnerElement.Append(potionTotalText);
    }

    public override void UpdateSelf(GameTime gameTime)
    {
        base.UpdateSelf(gameTime);

        Player player = Main.LocalPlayer;
        ExxoAvalonOriginsModPlayer modPlayer = player.GetModPlayer<ExxoAvalonOriginsModPlayer>();

        string rankTitle = $"Herbology {modPlayer.herbTier}";
        RankTitleText.InnerElement.SetText(rankTitle);

        string tier = $"Tier {(int)(modPlayer.herbTier) + 1} Herbologist";
        HerbTierText.InnerElement.SetText(tier);

        string herbTotal = modPlayer.herbTotal.ToString();
        herbTotalText.SetText(herbTotal);

        string potionTotal = modPlayer.potionTotal.ToString();
        potionTotalText.SetText(potionTotal);
    }
}
