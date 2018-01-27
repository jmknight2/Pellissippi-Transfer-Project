scanner.js
==========

The barcode scanning is powered by QuaggaJS! It's very powerfull, and is the highest rated javascript based solution in Github as of 2018.

scanner.js is simply a vessel to launching QuaggaJS. It clicks a hidden "input" button to request an image, then automatically starts scanning the barcode. If successfull, the result will be inserted into the desired input tag.

## Usage:
## scan(inputTag)

**WHERE:** inputTag is the scanner's locaiton to output. *(inputTag.value)* **any exhisting values will be lost.**

### Dependencies:
* ./quagga/dist/quagga.min.js
* ./scanner.js
*Insert these into "script" tags.*

## Example:

```html
<input id="fred" type="hidden"> <!--This is where we want our value to go.-->
<button onclick="scan(document.getElementById('fred'))">Scan a barcode!</button>
```