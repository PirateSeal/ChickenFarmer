﻿using SFML.Window;
using System;
using System.Threading;
using ChickenFarmer.Model;
using SFML.Graphics;
using SFML.System;

namespace ChickenFarmer.UI
{
    internal class InputHandler
    {
        GameLoop _ctxGameLoop;
        

        private static readonly Vector2f[] Direction = {
            new Vector2f( 5, 0),
            new Vector2f( -5, 0 ),
            new Vector2f(0, 5 ),
            new Vector2f( 0, -5 )
        };

        public InputHandler( GameLoop ctxGameLoop ) { _ctxGameLoop = ctxGameLoop; }

        public void Handle()
        {
            Vector2i mpos = Mouse.GetPosition( _ctxGameLoop.Window );
            FloatRect buttonSellEggsBound = _ctxGameLoop.FarmUI.ButtonSellEggs.GetGlobalBounds();

            //      var _menuBound = _ctxGameLoop.HouseMenu.Menu.GetGlobalBounds(); 
            //    var _buttonHenHouseUpgradeBound = _ctxGameLoop.HouseMenu.ButtonHenHouseUpgrade.GetGlobalBounds();
            //  var _buttonBuyChickenBound = _ctxGameLoop.HouseMenu.ButtonBuyChicken.GetGlobalBounds();


            if ( Keyboard.IsKeyPressed( Keyboard.Key.Escape ) )
            {
                _ctxGameLoop.Window.Close();
            }


            if (Keyboard.IsKeyPressed(Keyboard.Key.Z))
            {
                _ctxGameLoop.FarmUI.Farm.Player.Move(new Vector(Direction[3].X, Direction[3].Y));
                _ctxGameLoop.FarmUI._playerUI.AnimFrame++;
                _ctxGameLoop.FarmUI._playerUI.Direction = 1;
                _ctxGameLoop.View.Move(Direction[3]);
            }

            else if (Keyboard.IsKeyPressed(Keyboard.Key.S))
            {
                _ctxGameLoop.FarmUI.Farm.Player.Move(new Vector(Direction[2].X, Direction[2].Y));
                _ctxGameLoop.FarmUI._playerUI.AnimFrame++;
                _ctxGameLoop.FarmUI._playerUI.Direction = 4;
                _ctxGameLoop.View.Move(Direction[2]);
            }


            else if (Keyboard.IsKeyPressed(Keyboard.Key.Q))
            {
                _ctxGameLoop.FarmUI.Farm.Player.Move(new Vector(Direction[1].X, Direction[1].Y));
                _ctxGameLoop.FarmUI._playerUI.AnimFrame++;
                _ctxGameLoop.FarmUI._playerUI.Direction = 2;
                _ctxGameLoop.View.Move(Direction[1]);
            }
            else if (Keyboard.IsKeyPressed(Keyboard.Key.D))
            {
                _ctxGameLoop.FarmUI.Farm.Player.Move(new Vector(Direction[0].X, Direction[0].Y));
                _ctxGameLoop.FarmUI._playerUI.AnimFrame++;
                _ctxGameLoop.FarmUI._playerUI.Direction = 3;
                _ctxGameLoop.View.Move(Direction[0]);
            }



            foreach ( HenhouseUi house in _ctxGameLoop.FarmUI.HenhouseCollection.Henhouses )
            {
                if ( house.HouseSprite == null ) return;
                FloatRect buyChickenBound = house.HouseMenu.ButtonBuyChicken.GetGlobalBounds();

                if ( house.HouseSprite.GetGlobalBounds().Contains( mpos.X, mpos.Y ) &&
                     Mouse.IsButtonPressed( Mouse.Button.Left ) &&
                     house.HouseMenu.DrawState == false )
                {
                    foreach ( HenhouseUi item in _ctxGameLoop.FarmUI.HenhouseCollection.Henhouses )
                    {
                        if ( item != house )
                        {
                            if ( item.HouseMenu.DrawState )
                            {
                                item.HouseMenu.DrawState = false;
                            }
                        }
                    }

                    house.HouseMenu.DrawState = true;
                    Console.WriteLine( "button HenHouse Menu clicked" );
                    Thread.Sleep( 150 );
                }

                if ( !house.HouseMenu.Menu.GetGlobalBounds().Contains( mpos.X, mpos.Y ) &&
                     house.HouseMenu.DrawState == true &&
                     Mouse.IsButtonPressed( Mouse.Button.Left ) )
                {
                    house.HouseMenu.DrawState = false;
                    Console.WriteLine( "button HenHouse Menu not clicked" );
                    Thread.Sleep( 150 );
                }

                if ( house.HouseMenu.DrawState && buyChickenBound.Contains( mpos.X, mpos.Y ) &&
                     Mouse.IsButtonPressed( Mouse.Button.Left ) )
                {
                    _ctxGameLoop.FarmUI.Farm.Market.BuyChicken( 1, Chicken.Breed.Tier1 );
                    Console.WriteLine( "Chicken buyed" );

                    Thread.Sleep( 50 );
                }

                if ( house.HouseMenu.DrawState &&
                     house.HouseMenu.ButtonHenHouseUpgrade.GetGlobalBounds()
                         .Contains( mpos.X, mpos.Y ) && Mouse.IsButtonPressed( Mouse.Button.Left ) )
                {
                    _ctxGameLoop.FarmUI.Farm.Market.UpgradeHouse( house.Ctxhouse );
                    Console.WriteLine( "house upgrade" );

                    Thread.Sleep( 50 );
                }
            }

            if ( buttonSellEggsBound.Contains( mpos.X, mpos.Y ) &&
                 Mouse.IsButtonPressed( Mouse.Button.Left ) )
            {
                Market.Sellegg( _ctxGameLoop.FarmUI.Farm );
                Console.WriteLine( "button SellEggs clicked" );
            }
        }
    }
}
