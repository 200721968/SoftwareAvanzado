const express = require('express');
const app= express();
const path = require ('path');
//settings
app.set('port',4000)
app.set('views', path.join(__dirname, 'views'));
app.engine('html', require('ejs').renderFile);
app.set('view engine', 'ejs')

//routes
app.use(require('./routes/index'));

//static files 
app.use(express.static(path.join(__dirname, 'public')));
//listen
app.listen(app.get('port'), ()=>{
    console.log('Server Port:', app.get('port'));
});