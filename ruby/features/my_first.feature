Feature: Demo
@example
#  To find out what @example does, check out the cucumber.yml file!
  Scenario: Finding Ourselves
    Given I start the app
    Then I can get to the Start Page

    When I select the conference
    Then I should be on the Conference Page

    When I go to the "Exhibitors" page
    Then I can search by Name

    Then I can try to find "Xamarin" by scroll
    Then I can also search for "Xamarin" with the bar
    And I can select the first result

#  A Gemfile(.lock) will assure tests run with the same gem set.
#  Use 'bundle init' to create one, 'bundle update' to create a
#  Gemfile.lock, and 'bundle exec' to run tests defined in the .lock file.
#  Use text editors to amend the Gemfile.