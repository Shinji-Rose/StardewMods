using System;
using Microsoft.Xna.Framework;
using StardewModdingAPI;
using StardewModdingAPI.Events;
using StardewModdingAPI.Utilities;
using StardewValley;

namespace AutoPetCare
{

    public class Mod : StardewModdingAPI.Mod
    {

        override public void Entry(IModHelper helper)
        {
            helper.Events.GameLoop.DayStarted += DayStarted;

        }
        private void DayStarted(object sender, DayStartedEventArgs e)
        {
            FarmAnimalsPETPETPET();
        	PetsPETPETPET();
        	FillBOWLBOWLBOWL();
        }
        
        public void FarmAnimalsPETPETPET()
        {
			
            foreach (GameLocation location in Game1.locations)
            {
				
                foreach (FarmAnimal animal in location.getAllFarmAnimals())
                {
					
                    animal.wasPet.Value = true;
                    animal.friendshipTowardFarmer.Value = Math.Min(1000, animal.friendshipTowardFarmer + 15);
                }
            }
        }
        
        public void PetsPETPETPET()
        {

			foreach (GameLocation location in Game1.locations)
			{
				foreach (NPC entity in location.characters)
				{	
				
					if(entity is StardewValley.Characters.Pet petEntity)
					{
						
						petEntity.lastPetDay[Game1.player.UniqueMultiplayerID] = Game1.Date.TotalDays;
						petEntity.grantedFriendshipForPet.Value = true;
						petEntity.friendshipTowardFarmer.Set(Math.Min(1000, petEntity.friendshipTowardFarmer + 12));
						petEntity.timesPet.Value++;
					}
				}
			}
		}
		public void FillBOWLBOWLBOWL()
		{
			foreach (GameLocation location in Game1.locations)
			{
				foreach(StardewValley.Buildings.Building building in location.buildings)
				{
					if(building is StardewValley.Buildings.PetBowl bowl)
					{
						bowl.watered.Value = true;
					}
				}
			}
		}
    }
}
