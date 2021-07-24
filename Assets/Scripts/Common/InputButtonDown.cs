using UnityEngine;

public static class InputButtonDown {
    // 1. Button down properties.
    public static bool left1 { get { return IsButtonDown(left1Button, true); } }
    public static bool riught1 { get { return IsButtonDown(riught1Button, true); } }
    public static bool up1 { get { return IsButtonDown(up1Button); } }
    public static bool left2 { get { return IsButtonDown(left2Button, true); } }
    public static bool riught2 { get { return IsButtonDown(riught2Button, true); } }
    public static bool up2 { get { return IsButtonDown(up2Button); } }
    // 2. Button down repeatedly properties. (Optional)
    //public static bool exampleRepeat { get { return IsButtonDown(exampleButton, true); } }

    class Button {
        public string axis;
        public bool isNegative;
        public bool isPressed;
        public float nextTime;

        public Button(string axis) {
            this.axis = axis;
        }

        public Button(string axis, bool isNegative) {
            this.axis = axis;
            this.isNegative = isNegative;
        }
    }
    // 3. Button objects. Set axis name and is negative here.
    static Button left1Button = new Button("Horizontal_1P", true);
    static Button riught1Button = new Button("Horizontal_1P");
    static Button up1Button = new Button("Vertical_1P");
    static Button left2Button = new Button("Horizontal_2P", true);
    static Button riught2Button = new Button("Horizontal_2P");
    static Button up2Button = new Button("Vertical_2P");

    // 4. Repeat threshold and speed.
    static float threshold = 0f;
    static float speed = 0f;

    static bool IsButtonDown(Button button) {
        return IsButtonDown(button, false);
    }

    static bool IsButtonDown(Button button, bool isRepeatedly) {
        if ((button.isNegative && Input.GetAxisRaw(button.axis) < 0f)
            || (!button.isNegative && Input.GetAxisRaw(button.axis) > 0f)) {

            if ((isRepeatedly && Time.unscaledTime > button.nextTime)
                || (!isRepeatedly && !button.isPressed)) {

                if (isRepeatedly) button.nextTime = Time.unscaledTime + (button.isPressed ? speed : threshold);
                button.isPressed = true;
                return true;
            }
        } else {
            if (isRepeatedly) button.nextTime = 0f;
			button.isPressed = false;
        }
        return false;
    }
}
