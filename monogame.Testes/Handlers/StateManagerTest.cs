using NUnit.Framework;
using System;
using Microsoft.Xna.Framework.Input;
using monogame.Objects;

namespace monogame.Testes.Handlers
{
    [TestFixture()]
    public class StateManagerTest
    {
        Board gameBoard;
        BoardStateManager stateManager;
        MouseState currentState, previousState;

        [TestFixtureSetUp()]
        public void StateManagerSetUp()
        {
            gameBoard = new Board();
            stateManager = new BoardStateManager();
            previousState = new MouseState(250, 250, 0, ButtonState.Released, ButtonState.Released,
                      ButtonState.Released, ButtonState.Released, ButtonState.Released);
        }

        [Test()]
        public void MouseClickedRegion4()
        {
            currentState = new MouseState(250, 250, 0, ButtonState.Pressed, ButtonState.Released,
                    ButtonState.Released, ButtonState.Released, ButtonState.Released);
            Assert.That(stateManager.ClickedRegion(gameBoard.regions, currentState,
                                                        previousState), Is.EqualTo(4));
        }

        [Test()]
        public void MouseClickedRegion0()
        {
            currentState = new MouseState(105, 105, 0, ButtonState.Pressed, ButtonState.Released, 
                           ButtonState.Released, ButtonState.Released, ButtonState.Released);
            
            Assert.That(stateManager.ClickedRegion(gameBoard.regions, currentState, previousState), Is.EqualTo(0));
        }

        [Test()]
        public void ClickIsOutsideRegions()
        {
            currentState = new MouseState(50, 50, 0, ButtonState.Pressed, ButtonState.Released, 
                                 ButtonState.Released, ButtonState.Released, ButtonState.Released);

            Assert.That(stateManager.ClickedRegion(gameBoard.regions, currentState, previousState), 
                        Is.EqualTo(-1));
        }

        [Test()]
        public void ClickInSeparatorLinesRetunsNegative()
        {
            currentState = new MouseState(196, 101, 0, ButtonState.Pressed, ButtonState.Released,
                    ButtonState.Released, ButtonState.Released, ButtonState.Released);
            Assert.That(stateManager.ClickedRegion(gameBoard.regions, currentState,
                                        previousState), Is.EqualTo(-1));
        }
    }
}
