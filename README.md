# Background
For years, I have been planning for a project like this. I prepared my self quite well. I went through the entire CSS Level 2 specifiation along with the HTML 4.01 specification.

One of the most interesting things I found is this: Drawing HTML is no more than laying out a bunch of boxes with borders margins and paddings. Once you overpass this paradigm, everything else is to help the code actually place the boxes on the right place, and then paint the string each box contains.

Imagine the power that drawing full-rich-formatted HTML on your controls can give to your applications. Use bold when you need it, italics on every message, and borders and fonts as you may like or need everywhere on the desktop application. One of the first projects where I will use it is on the tooltips of my Ribbon Project.

Although I have not tested it on mono yet, there should be no problem at all, since all of the code on the library is managed code and the methods it use to paint are quite basic. It draws lines, rectangles, curves and text.

For now, the render looks really nice. Some times it can fool you to think your'e using a real Web Browser, trust me, download the demo, is just an exe and a dll.

# Using the code
The library locates the code under the System.Drawing.Html namespace. The controls that render HTML are under the System.Windows.Forms namespace.

The renderer follows the CSS Box Model. Box model is nothing but a tree of boxes, just as the tree of HTML, each of this boxes is represented by a very used class called CssBox. The start node is represented by the class InitialContainer.

All the known CSS properties apply to each of this boxes. Each box may contain any number of child boxes and just one parent. The only box that has no parent at all is the so called Initial Container.

A typical use of an Inital Container to draw HTML would look like this:

  //Create the InitialContainer
  InitialContainer c = new InitialContainer("<html>");
  
   
  //Give bounds to the container
  c.SetBounds(ClientRectangle);
  
   
  //Measure bounds of each box on the tree
  c.MeasureBounds(graphics);
   
  
  //Paint the HTML document
  c.Paint(graphics);


![](http://i3.codeplex.com/Download?ProjectName=HtmlRenderer&amp;DownloadId=54352)
*First a label, then a panel and at last a ToolTip, all of which support HTML rendering.*

You may never use it, since I provided Controls and Methods that creates this object for you.

## HtmlPanel
A panel that is ready to accept HTML code via its Text property. It's full name is System.Windows.Forms.HtmlPanel

The only properties you need to know are:
* AutoScroll. Activates/Deactivates the auto-scroll capabilities as you know. It is set to true by default.
* Text. Gets/Sets the HTML source.
* The panel will update the bounds of the elements as you scroll or resize the control.

## HtmlLabel
A label that is ready to accept HTML code via its Text property. It's full name is System.Windows.Forms.HtmlLabel

The only properties you need to know are:
* AutoScroll. Activates/Deactivates the auto-scroll capabilities as you know. It is set to true by default.
* AutoSize. Sets the size of the label automatically if activated.
* Text. Gets/Sets the HTML source.

Some interesting things:
* The label will update the bounds of the elements as you scroll or resize the control.
* The label can be transparent
* The panel has better performance than the label.

## HtmlToolTip
Works exactly like the ToolTip you already know, with the little difference that this tooltip will render HTML on it. It's full name is System.Windows.Forms.HtmlToolTip

There are no properties here to learn. Use it just the way you use the ToolTip that comes with the framework. Internally, it just handles the OwnerDraw event.

# Some features of my own
I took the liberty of adding a copule of features:
* Background gradients
* Rounded corners

These are achieved thru the following CSS properties:
* background-gradient: (color)
* background-gradient-angle: (number)
* corner-ne-radius: (length)
* corner-nw-radius: (length)
* corner-se-radius: (length)
* corner-se-radius: (length)
* corner-radius: (length){1,4} (shorthand for all corners)

What's currently supported by the Renderer?
* Most border, padding and margin and positioning CSSproperties (except for the height property).
* Text alignment horizontally and vertically, text indents too.
* Lists, ordered and unordered. Advanced numbering is not yet supported.
* Tables, almost at all of it. Cell combinations work quite well as far as I tested them.
* Fonts (partially) and Colors
* Backgrounds (just color)

