# Lab_Week4
week 4 lab d&d hp calcultor
initial psuedo code before editing into actual code


private int d6 = random.integer(1,6)
private int d8 = random.integer(1,8)
private int d10 = random.integer(1,10)
private int d12 = random.integer(1,12)

private dictionary<int, int> con_mod = new dictionary<int, int>
{
{1,-5}
{2,-4}
{3,-4}
{4,-3}
{5,-3)
// . . . and so on
}

public str name = "a"
public str class = "a"
public int level = 1
public int con_score = 0
public str race = "a"
public str feat = "a"
public bool hp_avarage = false
private int hp = 0

Debug.log("My character {0} is a level {1} {2} with a CON score of {3} and is of {4} race and", name, level, class, con_score, race)

class = (class)str.lowercase

if (hp_avarage){
if( class == "artificer"){
hp = (level * 4.5) + (level * con_mod[con_score])
}
if(class == "barbarian"){
hp = (level * 6.5) + (level * con_mod[con_score])
}
// and so on
}
else{
if( class == "artificer"){
for( int i =0; i < level; i++){
hp += d8 + con_mod[con_score]
}
}
if( class == "barbarian"){
for( int i =0; i < level; i++){
hp += d12 + con_mod[con_score]
}
}
// and so on
{

race = (race)str.lowercase

if (race == "dwarf"){
hp += (level * 2)
}

if (race == "orc"|| race == "goliath"){
hp += (level * 1)
}

feat = (feat)str.lowercase

if (feat == "tough"){
hp += (level * 2)
}

if (feat == "stout"){
hp += (level * 1)
}

if (feat == "tough") {
debug.log("has Tough feat.")
}
else if (feat == "stout") {
debug.log("has Stout feat.")
}
else{
debug.log("not Tough/Stout feat.")
}

if (hp_avarage) {
debug.log("I want the HP averaged.")
}
else{
debug.log("I want the HP rolled.")
}
