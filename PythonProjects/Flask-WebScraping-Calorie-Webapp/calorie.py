from temperature import Temperature


class Calorie:
    """
    Represents the amount of calories calculated with
    BMR = 10 * weight + 6.25 * height - 5 * age + 5 - 10 * temperature
    """

    def __init__(self, weight, height, age, temperature):
        self.temperature = temperature
        self.age = age
        self.height = height
        self.weight = weight

    def calculate(self):
        result = 10 * self.weight + 6.5 * self.height + 5 - self.temperature * 10
        return result


if __name__ == "__main__":
    temperature = Temperature("italy", "rome").get()
    calorie = Calorie(70, 175, 32, temperature)
    print(calorie.calculate())
