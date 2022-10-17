﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Gamestore1.Models;
using Gamestore1.Models.Repository;
using System.Web.ModelBinding;


namespace Gamestore1.Pages.Admin
{
    public partial class Games : System.Web.UI.Page
    {
        private Repository repository = new Repository();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        public IEnumerable<Game> GetGames()
        {
            return repository.Games;
        }

        public void UpdateGame(int GameID)
        {
            Game myGame = repository.Games
                .Where(p => p.GameId == GameID).FirstOrDefault();
            if (myGame != null && TryUpdateModel(myGame,
                new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveGame(myGame);
            }
        }

        public void DeleteGame(int GameID)
        {
            Game myGame = repository.Games
                .Where(p => p.GameId == GameID).FirstOrDefault();
            if (myGame != null)
            {
                repository.DeleteGame(myGame);
            }
        }

        public void InsertGame()
        {
            Game myGame = new Game();
            if (TryUpdateModel(myGame,
                new FormValueProvider(ModelBindingExecutionContext)))
            {
                repository.SaveGame(myGame);
            }
        }

    }
}