#include <Servo.h>
Servo servom;
int val;

void setup() {
Serial.begin(9600);
servom.attach(9);
}

void loop() {
}

void serialEvent(){
  val=Serial.parseInt();
if(val!=0){
  servom.write(val);
}
}
