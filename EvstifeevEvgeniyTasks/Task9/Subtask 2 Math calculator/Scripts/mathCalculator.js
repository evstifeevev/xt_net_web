var mathCalculatorWrapper = {
    reOperators: /\+|\*|\-|\/|\=/g,
    mathCalculator:function (line){
        if(line==undefined){
            console.error("Error: The mathemathical expression was empty.", line);
            return;
        }
        if(line.match(/((^(\*|\/))|(\-|\+|\*)\/)|((\-|\+|\/)\*)/g)!=null){
            console.error("Error: Wrong mathematical expression. ");
            return;
        }
        line = line.replace(/( *\-( *|\+*)\- *)/g,"+");
        line = line.replace(/(\+){2,}/g,"+");
        line = line.replace(/(\/\+){1,}/g,"/");
        line = line.replace(/(\*\+){1,}}/g,"*");
        line = line.replace(/(\*){2,}/g,"*");
        line = line.replace(/(\/){2,}/g,"/");
        var numbers = line.split(this.reOperators);
        var operators = line.match(this.reOperators);
        numbers.forEach(item =>{
            document.writeln(item);
        })
        if(operators==null)
        {
            operators=[];
            operators.push('=');    
        }
        
            operators.forEach(item =>{
                document.writeln(item);
            })  
        
        var find = operators.find(function(element){return element=='='});
        if(find==undefined || find==null){
            operators.push('=');
        }
         
        var result = operators.length>1? +numbers[0] : 0;
        if(operators.length==1 && operators[0]=='='){
            result=numbers[0];
        }
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
        document.writeln(result);
        console.log(result);
    },
};
mathCalculatorWrapper.mathCalculator("3 + 3 * 3 / 4 - 3 * 10e5")