"use strict";
function countdown(n)
{
  if(n < 1)
  {
    return [];
  }
  const revArr = countdown(n - 1);
  revArr.unshift(n);
  return revArr;
};

console.log(countdown(5));
console.log("----------------------------------");

function rangeOfNumbers(startNum, endNum) 
{
  if(startNum > endNum )
  {
    return [];
  }
  else{
    const arr = rangeOfNumbers(startNum, endNum - 1);
    arr.push(endNum);
    return arr;
  }
  
 
  
};
console.log(rangeOfNumbers(1,5));

const person = {
  name: "Zodiac Hasbro",
  age: 56
};
const greeting = `Hello, my name is ${person.name}! 
I am ${person.age} years old.`;
console.log(greeting);