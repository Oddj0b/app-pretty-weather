#!/usr/bin/env bash

echo "Found UI tests projects:"
find $APPCENTER_SOURCE_DIRECTORY -regex '*.UITest.*\.csproj' -exec echo {} \;
echo
echo "Building UI test projects:"
find $APPCENTER_SOURCE_DIRECTORY -regex '*.UITEst.*\.csproj' -exec msbuild {} \;
echo "Compiled projects to run UI tests:"
find $APPCENTER_SOURCE_DIRECTORY -regex '*.bin.*UITest.*\.dll' -exec echo {} \;
echo "Running UI test in App Center Test:"
appPath= find APPCENTER_OUTPUT_DIRECTORY -regex '*.bin.*ipa' echo {}\;
buildDir= find $APPCENTER_SOURCE_DIRECTORY -regex '*.bin.*UITEST.*\' -exec echo{}
find $APPCENTER_SOURCE_DIRECTORY -regex '*.bin.*UITest.*\.dll' -exec appcenter test run uitest --app $APP_OWNER --devices $DEVICE_SET --test-series "$APPCENTER_BRANCH-$APPCENTER_TRIGGER" --locale $LOCALE --app-path $appPath --build-dir $buildDir
