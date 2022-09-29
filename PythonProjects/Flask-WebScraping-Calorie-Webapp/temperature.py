import requests
import bs4

class Temperature:
    """
    Represent the temperature value extracted from the timeanddate.com/weather webpage
    """
    base_url = "https://www.timeanddate.com/weather/"

    def __init__(self, country, city):
        self.city = city.strip().replace(" ", "-")
        self.country = country.strip().replace(" ", "-")

    def get(self):
        req = requests.get(f"{self.base_url}{self.country}/{self.city}")
        soup = bs4.BeautifulSoup(req.text, 'lxml')
        result = float(soup.select('.h2')[0].getText().replace("°C", ""))
        return result


if __name__ == "__main__":
    temp = Temperature("uk", "liverpool")
    print(temp.get())
