using System.Linq;
using System.Threading.Tasks;
using Alsein.Extensions;

namespace Cynthia.Card
{
     [CardEffectId("70082")]//席安娜:黄粱一梦
     public class SyannagoldenmilleTDream : CardEffect
     {//使场上战力最高的牌获得“佚亡”效果。若其已被增益，则使其直接被放逐。
          public SyannagoldenmilleTDream(GameCard card) : base(card) { }
          public override async Task<int> CardUseEffect()
          {
               var cards = Game.GetAllCard(Game.AnotherPlayer(Card.PlayerIndex)).Where(x =>x.Status.CardRow.IsOnPlace()).WhereAllHighest().ToList();
               foreach (var card in cards)
               {
                    if (Card.Status.HealthStatus > 0 )
                    {
                         await card.Effect.Banish();
                    }
                    else
                    {
                         card.Status.IsDoomed = true;
                    }
               }
               return 0;
          }
     }
}
