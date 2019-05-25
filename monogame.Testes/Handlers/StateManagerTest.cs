using NUnit.Framework;
using System;
using Microsoft.Xna.Framework.Input;
using Microsoft.Xna.Framework.Graphics;
using monogame.Objects;

namespace monogame.Testes.Handlers
{
    [TestFixture]
    public class StateManagerTest
    {
        Board gameBoard;
        BoardStateManager stateManager;
        MouseState currentState, previousState;

        [TestFixtureSetUp]
        public void StateManagerSetUp()
        {
            SpriteFont font = null;
            gameBoard = new Board(font);
            stateManager = new BoardStateManager();
            previousState = new MouseState(250, 250, 0, ButtonState.Released, ButtonState.Released,
                      ButtonState.Released, ButtonState.Released, ButtonState.Released);
        }

        [Test]
        public void MouseClickedRegion4()
        {
            currentState = new MouseState(250, 250, 0, ButtonState.Pressed, ButtonState.Released,
                    ButtonState.Released, ButtonState.Released, ButtonState.Released);
            Assert.That(BoardStateManager.ClickedRegion(gameBoard.regions, currentState,
                                                        previousState), Is.EqualTo(4));
        }

        [Test]
        public void MouseClickedRegion0()
        {
            currentState = new MouseState(105, 105, 0, ButtonState.Pressed, ButtonState.Released, 
                           ButtonState.Released, ButtonState.Released, ButtonState.Released);
            
            Assert.That(BoardStateManager.ClickedRegion(gameBoard.regions, currentState, previousState), Is.EqualTo(0));
        }

        [Test]
        public void ClickIsOutsideRegions()
        {
            currentState = new MouseState(50, 50, 0, ButtonState.Pressed, ButtonState.Released, 
                                 ButtonState.Released, ButtonState.Released, ButtonState.Released);

            Assert.That(BoardStateManager.ClickedRegion(gameBoard.regions, currentState, previousState), 
                        Is.EqualTo(-1));
        }

        [Test]
        public void ClickInSeparatorLinesRetunsNegative()
        {
            currentState = new MouseState(196, 101, 0, ButtonState.Pressed, ButtonState.Released,
                    ButtonState.Released, ButtonState.Released, ButtonState.Released);
            Assert.That(BoardStateManager.ClickedRegion(gameBoard.regions, currentState,
                                        previousState), Is.EqualTo(-1));
        }

        [Test]
        public void ClickedRegionHasChangedState()
        {
            currentState = new MouseState(250, 250, 0, ButtonState.Pressed, ButtonState.Released,
                    ButtonState.Released, ButtonState.Released, ButtonState.Released);
            var idx = BoardStateManager.ClickedRegion(gameBoard.regions, currentState, previousState);
            BoardStateManager.UpdateClickedRegionState(gameBoard.regions, idx);
            Assert.That(gameBoard.regions[4].State, Is.EqualTo(1));
        }

        [Test]
        public void PlayerStateHasUpdated()
        {
            BoardStateManager.currentPlayer = 1;
            BoardStateManager.UpdatePlayerState();
            Assert.That(BoardStateManager.currentPlayer, Is.EqualTo(-1));
            BoardStateManager.UpdatePlayerState();
            Assert.That(BoardStateManager.currentPlayer, Is.EqualTo(1));
        }

        [Test]
        public void DifferentClickedRegionsHaveDiffStates()
        {
            gameBoard.regions[3].InteractWithRegionState();
            Assert.That(gameBoard.regions[3].State, Is.EqualTo(-1));
            gameBoard.regions[4].InteractWithRegionState();
            Assert.That(gameBoard.regions[4].State, Is.EqualTo(1));
        }

        [Test]
        public void UpdateBoardMouseStates()
        {
            currentState = new MouseState(250, 250, 0, ButtonState.Pressed, ButtonState.Released,
                    ButtonState.Released, ButtonState.Released, ButtonState.Released);
            MouseState newState = new MouseState(666, 666, 0, ButtonState.Pressed, ButtonState.Released,
                    ButtonState.Released, ButtonState.Released, ButtonState.Released);
            gameBoard.Current = currentState;
            gameBoard.Previous = previousState;
            gameBoard.UpdateMouse(newState);
            Assert.That(gameBoard.Current, Is.EqualTo(newState));
            Assert.That(gameBoard.Previous, Is.EqualTo(currentState));
        }

        [Test]
        public void RegionHasBeenClickedWithCorrectPlayers()
        {
            Assert.That(gameBoard.regions[0].State, Is.EqualTo(0));
            Assert.That(gameBoard.regions[1].State, Is.EqualTo(0));
            gameBoard.UpdateCLicks(0);
            gameBoard.UpdateCLicks(1);
            Assert.That(gameBoard.regions[0].State, Is.EqualTo(1));
            Assert.That(gameBoard.regions[1].State, Is.EqualTo(-1));
        }
    }
}
