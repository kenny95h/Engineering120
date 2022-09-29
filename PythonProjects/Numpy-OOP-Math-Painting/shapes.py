from typing import Tuple


class Square:

    def __init__(self, x: int, y: int, side_a: int, color: Tuple[int, int, int]):
        self.color = color
        self.side_a = side_a
        self.y = y
        self.x = x

    def draw(self, canvas):
        """Draw the current square on to the canvas"""
        canvas.data[self.y: self.y + self.side_a, self.x: self.x + self.side_a] = self.color


class Rectangle:
    """A rectangle shape that can be drawn on a Canvas object"""

    def __init__(self, x: int, y: int, height: int, width: int, color: Tuple[int, int, int]):
        self.color = color
        self.width = width
        self.height = height
        self.y = y
        self.x = x

    def draw(self, canvas):
        """Draw the current rectangle on to the canvas"""
        canvas.data[self.y: self.y + self.height, self.x: self.x + self.width] = self.color
