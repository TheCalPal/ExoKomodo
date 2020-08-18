function startP5(p5Implementation, container)
{
    let sketch = function(p) {
        window.p5Instance = p;

        p.fonts = {};
        p.images = {};

        p.doubleClicked = function() {
            return p5Implementation.invokeMethodAsync('doubleClicked');
        }

        p.draw = function() {
            p5Implementation.invokeMethodAsync('draw');
        }

        p.fontDotnet = function(id, size) {
            let font = this.fonts[id];
            if (!size) {
                this.textFont(font);
            } else {
                this.textFont(font, size);
            }
        }

        p.getValue = function(valueName) {
            return this[valueName];
        }

        p.imageDotnet = function(id, x, y, width, height) {
            this.image(
                this.images[id],
                x,
                y,
                width,
                height
            );
        }

        p.imageHeightDotnet = function(id) {
            return this.images[id].height;
        }

        p.imageWidthDotnet = function(id) {
            return this.images[id].width;
        }
        
        p.invokeP5Function = function(functionName) {
            var args = Array.prototype.splice.call(arguments, 1);
            this[functionName].apply(this, args);
        }

        p.invokeP5FunctionAndReturn = function(functionName) {
            var args = Array.prototype.splice.call(arguments, 1);u
            return this[functionName].apply(this, args);
        }

        p.keyPressed = function() {
            return p5Implementation.invokeMethodAsync('keyPressed');
        }

        p.keyReleased = function() {
            return p5Implementation.invokeMethodAsync('keyReleased');
        }

        p.keyTyped = function() {
            return p5Implementation.invokeMethodAsync('keyTyped');
        }

        p.loadImageDotnet = function(imagePath) {
            this.images[imagePath] = this.loadImage(imagePath);
            return {
                id: imagePath,
            };
        }

        p.loadFontDotnet = function(fontPath) {
            this.fonts[fontPath] = this.loadFont(fontPath);
            return {
                id: fontPath,
            };
        }

        p.loadPixelsDotnet = function(id) {
            this.images[id].loadPixels();
        }

        p.mouseClicked = function() {
            return p5Implementation.invokeMethodAsync('mouseClicked');
        }

        p.mouseDragged = function() {
            return p5Implementation.invokeMethodAsync('mouseDragged');
        }

        p.mouseMoved = function() {
            return p5Implementation.invokeMethodAsync('mouseMoved');
        }

        p.mousePressed = function() {
            return p5Implementation.invokeMethodAsync('mousePressed');
        }

        p.mouseReleased = function() {
            return p5Implementation.invokeMethodAsync('mouseReleased');
        }

        p.preload = function() {
            p5Implementation.invokeMethodAsync('preload');
        }
        
        p.setup = function() {
            p5Implementation.invokeMethodAsync('setup');
        }

        p.windowResized = function() {
            p5Implementation.invokeMethodAsync('windowResized');
        }
    };
    new p5(sketch, window.document.getElementById(container));
}