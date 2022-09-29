from canvas import Canvas
from shapes import Square, Rectangle


class Painting:

    def value_exception(input_q):
        while True:
            try:
                user_input = int(input(input_q))
            except ValueError:
                continue
            else:
                break
        return user_input

    # Create canvas - sidea - sideb - color(black/white)
    canvas_height = value_exception("Please enter the height of the canvas: ")

    canvas_width = value_exception("Please enter the width of the canvas: ")

    colors = {"white": (255, 255, 255), "black": (0, 0, 0)}
    while True:
        canvas_color = input("Please enter the color of the canvas: black/white ").lower()
        if canvas_color in colors:
            break
        else:
            print("Must be either 'black' or 'white'")
            continue

    canvas = Canvas(canvas_height, canvas_width, colors[canvas_color])

    while True:
        draw_rect = input("Do you want to add a rectangle? Y/n ").lower()
        if draw_rect == "n":
            break
        else:
            # create rectangles - start x - start y - sidea - sideb - color(R/G/B)
            while True:
                x = value_exception("Please enter the x coordinate of the rectangle: ")
                if x > canvas.width:
                    print(f"The x coordinate '{x}' is not within the canvas width '{canvas.width}'")
                    continue
                elif x > canvas.width - 20:
                    happy = input(f"The x coordinate '{x}' is close to the width of the canvas '{canvas.width}'. "
                                  + "Were you happy with this choice? Y/n ").lower()
                    if happy == "n":
                        continue
                    else:
                        break
                else:
                    break
            while True:
                y = value_exception("Please enter the y coordinate of the rectangle: ")
                if y > canvas.height:
                    print(f"The y coordinate '{y}' is not within the canvas height '{canvas.height}'")
                    continue
                elif y > canvas.height - 20:
                    happy = input(f"The y coordinate '{y}' is close to the height of the canvas '{canvas.height}'. "
                                  + "Were you happy with this choice? Y/n ").lower()
                    if happy == "n":
                        continue
                    else:
                        break
                else:
                    break

            while True:
                rect_width = value_exception("Please enter the width of the rectangle: ")
                if rect_width > canvas.width - x:
                    happy = input(f"The width of the rectangle '{rect_width}' will not fit on the remaining canvas width '{canvas.width - x}'. "
                                  + "Were you happy with this choice? Y/n ").lower()
                    if happy == "n":
                        continue
                    else:
                        break
                else:
                    break
            while True:
                rect_height = value_exception("Please enter the height of the rectangle: ")
                if rect_height > canvas.height - y:
                    happy = input(f"The height of the rectangle '{rect_height}' will not fit on the remaining canvas "
                                  f"height '{canvas.height - y}'. "
                                  + "Were you happy with this choice? Y/n ").lower()
                    if happy == "n":
                        continue
                    else:
                        break
                else:
                    break

            while True:
                red = value_exception("Please enter the red intensity: ")
                if red > 255 or red < 0:
                    print("Color intensity must be between 0 and 255")
                    continue
                else:
                    break
            while True:
                green = value_exception("Please enter the green intensity: ")
                if green > 255 or green < 0:
                    print("Color intensity must be between 0 and 255")
                    continue
                else:
                    break
            while True:
                blue = value_exception("Please enter the blue intensity: ")
                if blue > 255 or blue < 0:
                    print("Color intensity must be between 0 and 255")
                    continue
                else:
                    break

        Rectangle(x, y, rect_height, rect_width, (red, green, blue)).draw(canvas)

    # while not quit
    while True:
        draw_sqr = input("Do you want to add a square? Y/n ").lower()
        if draw_sqr == "n":
            break
        else:
            # create squares - start x - start y - side - color(R/G/B)
            while True:
                x = value_exception("Please enter the x coordinate of the square: ")
                if x > canvas.width:
                    print(f"The x coordinate '{x}' is not within the canvas width '{canvas.width}'")
                    continue
                elif x > canvas.width - 20:
                    happy = input(f"The x coordinate '{x}' is close to the width of the canvas '{canvas.width}'. "
                                  + "Were you happy with this choice? Y/n ").lower()
                    if happy == "n":
                        continue
                    else:
                        break
                else:
                    break
            while True:
                y = value_exception("Please enter the y coordinate of the square: ")
                if y > canvas.height:
                    print(f"The y coordinate '{y}' is not within the canvas height '{canvas.height}'")
                    continue
                elif y > canvas.height - 20:
                    happy = input(f"The y coordinate '{y}' is close to the height of the canvas '{canvas.height}'. "
                                  + "Were you happy with this choice? Y/n ").lower()
                    if happy == "n":
                        continue
                    else:
                        break
                else:
                    break

            while True:
                sqr_side = value_exception("Please enter the size of the square: ")
                if sqr_side > canvas.width - x:
                    happy = input(f"The width of the square '{sqr_side}' will not fit on the remaining canvas width '{canvas.width - x}'. "
                                  + "Were you happy with this choice? Y/n ").lower()
                    if happy == "n":
                        continue
                    else:
                        break
                elif sqr_side > canvas.height - y:
                    happy = input(
                        f"The height of the square '{sqr_side}' will not fit on the remaining canvas height '{canvas.height - x}'. "
                        + "Were you happy with this choice? Y/n ").lower()
                    if happy == "n":
                        continue
                    else:
                        break
                else:
                    break

            while True:
                red = value_exception("Please enter the red intensity: ")
                if red > 255 or red < 0:
                    print("Color intensity must be between 0 and 255")
                    continue
                else:
                    break
            while True:
                green = value_exception("Please enter the green intensity: ")
                if green > 255 or green < 0:
                    print("Color intensity must be between 0 and 255")
                    continue
                else:
                    break
            while True:
                blue = value_exception("Please enter the blue intensity: ")
                if blue > 255 or blue < 0:
                    print("Color intensity must be between 0 and 255")
                    continue
                else:
                    break

        Square(x, y, sqr_side, (red, green, blue)).draw(canvas)

    # create canvas image
    image_name = input("Please enter the filename of your image: ")
    canvas.make(f"{image_name}.png")


if __name__ == "__main__":
    Painting()
