import inspect

import justpy as jp

from webapp import page
from webapp.about import About
from webapp.dictionary import Dictionary
from webapp.home import Home

imports = list(globals().values())

for value in imports:
    if inspect.isclass(value):
        if issubclass(value, page.Page) and hasattr(value, "path"):
            jp.Route(value.path, value.serve)

# jp.Route(Home.path, Home.serve)
# jp.Route(About.path, About.serve)
# jp.Route(Dictionary.path, Dictionary.serve)

jp.justpy(port=8001)
