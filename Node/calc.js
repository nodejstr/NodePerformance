function calc()
{
    var i = 0,
	result = 0
    var date1 = new Date();
    for(i=0;i<1000000000;i++){
        result+=Math.sqrt(i)
    }
    console.log((new Date())-date1)
    console.log(result)
}
console.log('started')
calc()
console.log('ended')