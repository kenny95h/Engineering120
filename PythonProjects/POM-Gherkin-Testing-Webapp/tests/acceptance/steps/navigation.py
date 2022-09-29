from behave import *
from selenium import webdriver

from tests.acceptance.page_model.blog_page import BlogPage
from tests.acceptance.page_model.home_page import HomePage
from tests.acceptance.page_model.new_post_page import NewPostPage

use_step_matcher('re') # allows us to use the steps from the feature file

@given('I am on the homepage') # calls this test step each time this name is called in the feature
def step_impl(context):
    context.driver = webdriver.Chrome() # launches a new Chrome window, and gives access to it through the variable
    page = HomePage(context.driver)
    context.driver.get(page.url) # navigate to webpage

@given('I am on the blog page') # calls this test step each time this name is called in the feature
def step_impl(context):
    context.driver = webdriver.Chrome() # launches a new Chrome window, and gives access to it through the variable
    page = BlogPage(context.driver)
    context.driver.get(page.url) # navigate to webpage

@given('I am on the new post page')  # calls this test step each time this name is called in the feature
def step_impl(context):
    context.driver = webdriver.Chrome()  # launches a new Chrome window, and gives access to it through the variable
    page = NewPostPage(context.driver)
    context.driver.get(page.url)  # navigate to webpage

@then('I am on the blog page')
def step_impl(context):
    expected_url = BlogPage(context.driver).url
    assert context.driver.current_url == expected_url

@then('I am on the homepage')
def step_impl(context):
    expected_url = HomePage(context.driver).url
    assert context.driver.current_url == expected_url