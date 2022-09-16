import folium
import pandas

map = folium.Map(location=[40.58, -104.09], zoom_start=5.5, tiles = "Stamen Terrain")

data = pandas.read_csv("Volcanos.csv")
lat = list(data["LAT"])
lon = list(data["LON"])
elev = list(data["ELEV"])
name = list(data["NAME"])

def color_prod(elev):
    if elev <= 1500:
        return "green"
    elif elev >= 3000:
        return "red"
    return "orange"


html = """
Volcano name:<br>
<a href="https://www.google.com/search?q=%22{}%22"
target="_blank">{}</a><br>
Height: {}m
"""

fgp = folium.FeatureGroup(name="Population")

fgp.add_child(folium.GeoJson(data=open("world.json", "r", encoding="utf-8-sig").read(),
style_function=lambda x: {"fillColor": "green" if x["properties"]["POP2005"] < 100000000 
else "orange" if 100000000 <= x["properties"]["POP2005"] < 200000000 else "red" if 200000000 
<= x["properties"]["POP2005"] < 800000000 else "purple", "fillOpacity": 0.4}))

fgv = folium.FeatureGroup(name="Volcanos")

for lt, ln, el, name in zip(lat, lon, elev, name):
    iframe = folium.IFrame(html=html.format(name, name, int(el)), width=200, height=80)
    fgv.add_child(folium.CircleMarker(location=[lt, ln], popup=folium.Popup(iframe), radius=8, fill=True, 
    fill_opacity=1, fill_color=color_prod(el), color="black"))

map.add_child(fgp)
map.add_child(fgv)

map.add_child(folium.LayerControl())

map.save("Map1.html")