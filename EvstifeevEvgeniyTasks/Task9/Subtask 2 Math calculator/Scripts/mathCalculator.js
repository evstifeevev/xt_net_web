var mathCalculatorWrapper = {
    reOperators: /\+|\*|\-|\/|\=/g,
    mathCalculator:function (line){
        var numbers = line.split(this.reOperators);
        var operators = line.match(this.reOperators);
        var result = operators.length>1? +numbers[0] : 0;
        for(var operationIndex=0;operationIndex<operators.length-1;
            operationIndex++){
            switch(operators[operationIndex]){
                case '+':
                    result+=+numbers[operationIndex+1];
                    break;
                case '-':
                    result-=+numbers[operationIndex+1];
                    break;
                case '*':
                    result*=+numbers[operationIndex+1];
                    break;
                case '/':
                    result/=+numbers[operationIndex+1];
                    break;
            }
        }
        result=Math.round(result*100)/100;
		document.write(line);
        document.write(result);
    },
};
mathCalculatorWrapper.mathCalculator("3 + 3 * 3 / 4 - 3 * 10e5 = ")