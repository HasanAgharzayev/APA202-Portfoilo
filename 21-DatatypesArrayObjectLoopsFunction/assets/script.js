let numbers = [1, 2, 2, 3, 4, 4, 4, 5];
let uniqueArray = [];
let duplicateCount = 0;

for (let i = 0; i < numbers.length; i++) {
    let exists = false;
    for (let j = 0; j < uniqueArray.length; j++) {
        if (numbers[i] === uniqueArray[j]) {
            exists = true;
            break;
        }
    }

    if (!exists) {
        uniqueArray.push(numbers[i]);
    } else {
        duplicateCount++;
    }
}

console.log("Unique Array:", uniqueArray);
console.log("Duplicate Count:", duplicateCount);



function isPalindrome(word) {
    let reversedWord = "";
    for (let i = word.length - 1; i >= 0; i--) {
        reversedWord += word[i];
    }

    return word === reversedWord;
}

console.log(isPalindrome("level"));
console.log(isPalindrome("hello"));



function countGreaterElements(inputNumber, array) {
    let count = 0;
    for (let i = 0; i < array.length; i++) {
        if (inputNumber < array[i]) {
            count++;
        }
    }
    return count;
}
let data = [10, 20, 30, 40, 50];
console.log("Count:", countGreaterElements(25, data));




function checkNumberType(num) {
    let sumOfDivisors = 0;
    for (let i = 1; i < num; i++) {
        if (num % i === 0) {
            sumOfDivisors += i;
        }
    }

    if (sumOfDivisors > num) {
        return "Abundant";
    } else {
        return "Deficient";
    }
}

console.log(checkNumberType(12));
console.log(checkNumberType(10));



function getSquaredArray(arr) {
    let resultArray = [];
    for (let i = 0; i < arr.length; i++) {
        resultArray.push(arr[i] * arr[i]);
    }
    return resultArray;
}



let originalArray = [1, 2, 3, 4];
let squaredArray = getSquaredArray(originalArray);

console.log("Original:", originalArray);
console.log("Squared:", squaredArray);
