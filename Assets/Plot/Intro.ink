-> Begin

== Begin ==
#pic black
#color white
#Name 我
(……)
(头好痛……)

#pic black
#color red
#Name ???
诶，还活着吗？

#pic black
#color white
#Name 我
(……有人喊我……?)

#pic black
#color red
#Name ???
不对啊...明明是活着的才对啊....
呐，你醒着的吧？

* [有人喊我...?] -> awake
* [...] -> KickAwake

== awake ==
#pic Kocolo
哦！你醒了呀！看起来还蛮精神的嘛。不错不错！

* [……你是谁？] -> KokocoIntro
* [……这里是..?] -> WhereIsHere

== KickAwake == 
#name 我
好痛...!

#pic Kocolo
#color red
#name ???
什么啊，这不是醒着嘛。

#Name 我
你踢的也太用力了吧...没必要，真的没必要的...

#pic Kocolo
#color red
#name ???
反正我喊你你也不起来，那就只能用这种方式了叭。

* [说回来...你是谁啊？] -> KokocoIntro
* [这么说来...这里是..?] -> WhereIsHere

