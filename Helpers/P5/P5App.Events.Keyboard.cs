using Microsoft.JSInterop;

namespace ExoKomodo.Helpers.P5
{
    public abstract partial class P5App
    {
        #region Public

        #region Members
        public string Key => _jsRuntime.Invoke<string>(
            _p5GetValue,
            "key"
        );
        public uint KeyCode => _jsRuntime.Invoke<uint>(
            _p5GetValue,
            "keyCode"
        );
        public bool KeyIsPressed => _jsRuntime.Invoke<bool>(
            _p5GetValue,
            "keyIsPressed"
        );
        #endregion

        #region Hooks
        [JSInvokable("keyPressed")]
        public virtual bool KeyPressed()
        {
            return false; // Event prevent default
        }

        [JSInvokable("keyReleased")]
        public virtual bool KeyReleased()
        {
            return false; // Event prevent default
        }

        [JSInvokable("keyTyped")]
        public virtual bool KeyTyped()
        {
            return false; // Event prevent default
        }
        #endregion

        #region Member Methods
        public bool IsKeyDown(uint code) => _jsRuntime.Invoke<bool>(
            _p5InvokeFunctionAndReturn,
            "keyIsDown",
            code
        );
        #endregion

        #endregion
    }
}