import json
from difflib import get_close_matches
import random

data = json.load(open("data.json"))

def definition(word):
    if word in data:
        return data[word]
    elif word.lower() in data:
        return data[word.lower()]
    elif word.title() in data:
        return data[word.title()]
    elif word.upper() in data:
        return data[word.upper()]
    elif get_close_matches(word, data.keys(), cutoff=0.8):
        if input(f"Did you mean to enter '{get_close_matches(word, data.keys())[0]}'? (Y/n): ").lower() != "n":
            return data[get_close_matches(word, data.keys())[0]]
    return f"Unable to find a definition for {word}. Please enter a different word"

def thesaurus():
    while True:
        play = input("Do you want to use the Thesaurus? (Y/n): ")
        if play.lower() == "n":
            break
        else:
            while True:
                word = input("Enter word to get definition: ")
                defi = []
                d = (definition(word))
                defi.extend(d)
                if "Unable to find" in d:
                    print(d)
                    break
                else:
                    num_defs = len(defi)
                    rand_defi = defi[random.randint(0,num_defs-1)]
                    print(rand_defi)
                    while True:
                        happy = input("Are you happy with this definition? (Y/n): ")
                        defi.remove(rand_defi)
                        if happy != "n":
                            break
                        elif not defi:
                            print("No more definitions available")
                            break
                        else:
                            num_defs = len(defi)
                            rand_defi = defi[random.randint(0,num_defs-1)]
                            print(rand_defi)
                    break

thesaurus()