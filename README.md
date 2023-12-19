# JTTools

JT808、JT809、JT1078、JTNE解析工具

<a href="https://jttools.smallchi.cn/" target="_blank">在线解析工具</a>

使用systemd托管应用程序

``` 1
cp /home/jttools/jttools.service /etc/systemd/system/jttools.service
chmod u+x /home/jttools/jttools
systemctl daemon-reload

systemctl satrt jttools.service
systemctl status jttools.service
systemctl stop jttools.service

service jttools satrt
service jttools status
service jttools stop
```

使用nodejs的PM2托管应用程序

``` 2
pm2 start "dotnet JTTools.dll ASPNETCORE_ENVIRONMENT=Production" -n "JTTools.18888" -o "/home/Logs/JTTools/out.log" -e "/home/Logs/JTTools/error.log"
```
