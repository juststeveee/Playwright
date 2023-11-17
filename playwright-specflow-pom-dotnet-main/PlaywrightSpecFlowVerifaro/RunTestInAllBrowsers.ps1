# script to test in multiple browsers!

echo "Running Test in Chromium"
dotnet test --settings:chromium.runsettings

echo "Running Test in firefox"
dotnet test --settings:firefox.runsettings

echo "Running Test in Webkit"
dotnet test --settings:webkit.runsettings