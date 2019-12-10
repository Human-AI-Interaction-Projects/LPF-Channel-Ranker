void setup() {
  // put your setup code here, to run once:
  pinMode(A0,INPUT);
  pinMode(A1,INPUT);
  pinMode(A2,INPUT);
  pinMode(A3,INPUT);
  pinMode(A4,INPUT);
  pinMode(A5,INPUT);
  pinMode(A6,INPUT);
  pinMode(A7,INPUT);
  Serial.begin(9600);
}
int Out1 = 0;
int Out2 = 0;
int Out3 = 0;
int Out4 = 0;
int Out5 = 0;
int Out6 = 0;
int Out7 = 0;
int Out0 = 0;
void loop() {
  // put your main code here, to run repeatedly:
  delay(10);
  Out0 = analogRead(A0);
  Out1 = analogRead(A1);
  Out2 = analogRead(A2);
  Out3 = analogRead(A3);
  Out4 = analogRead(A4);
  Out5 = analogRead(A5);
  Out6 = analogRead(A6);
  Out7 = analogRead(A7);
  
//  Serial.write(Out0);
//  delay(1000);
//  Serial.write(Out1);
//  delay(1000);
//  Serial.write(Out2);
//  delay(1000);
//  Serial.write(Out3);
//  delay(1000);
//  Serial.write(Out4);
//  delay(1000);
//  Serial.write(Out5);
//  delay(1000);
//  Serial.write(Out6);
//  delay(1000);
  Serial.println(Out7);
  //Serial.write(Out7);
  
}
