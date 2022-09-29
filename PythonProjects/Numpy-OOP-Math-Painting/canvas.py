from typing import Tuple

import numpy as np
from PIL import Image


class Canvas:
    """Object to act as a canvas where all shapes will be drawn"""

    def __init__(self, height: int, width: int, color: Tuple[int, int, int]):
        self.color = color
        self.height = height
        self.width = width

        self.data = np.zeros((self.height, self.width, 3), dtype=np.uint8)
        self.data[:] = self.color

    def make(self, path):
        """Convert current array into an image file"""
        img = Image.fromarray(self.data, "RGB")
        img.save(path)
