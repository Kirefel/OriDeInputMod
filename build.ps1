msbuild /t:Build /restore /p:Configuration=Release /p:OutDir=..\build

rm -R .\release -ErrorAction SilentlyContinue
mkdir .\release\

cp .\build\OriDeInputMod.dll .\release\
cp .\mod.json .\release\

rm .\OriDeInputMod.zip -ErrorAction SilentlyContinue
powershell Compress-Archive .\release\* .\OriDeInputMod.zip
