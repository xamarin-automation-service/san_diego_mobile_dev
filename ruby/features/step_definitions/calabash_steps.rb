require 'calabash-android/calabash_steps'

Given(/^I start the app$/) do
  # Using Page Object Programming assures methods can only be called on
  # a corresponding page. It also makes reading and updating code easier.
  # The await method asserts the query string in the trait method exists.
  # This replaces the default ruby initialize method.
  @startpage = page(StartPage).await timeout:60
end

Then(/^I can get to the Start Page$/) do
  @startpage.dismissDialog
end

When(/^I select the conference$/) do
  @startpage.confe
end

Then(/^I should be on the Conference Page$/) do
  @confPage = page(ConfPage).await timeout:60
end

When(/^I go to the "([^"]*)" page$/) do |arg|
  # The symbols are regex filters and accepts everything between the outermost
  # quotes as string variables to pass into the methods.
  @confPage.toSubPage(arg)
end

Then(/^I can search by Name$/) do
  @confPage.searchName
end

Then(/^I can try to find "([^"]*)" by scroll$/) do |arg|
  @confPage.searchScroll(arg)
end

Then(/^I can also search for "([^"]*)" with the bar$/) do |arg|
  @confPage.searchBar(arg)
end

And(/^I can select the first result$/) do
  # Of course, procedural code can also be written directly into the step definitions
  touch "* id:'list_item_title' text:'Xamarin'"
  wait_for_elements_exist ["* text:'Xamarin'"]
end