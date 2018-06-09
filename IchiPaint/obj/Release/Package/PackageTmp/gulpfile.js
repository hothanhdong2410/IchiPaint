// Sass configuration
var gulp = require('gulp');
var sass = require('gulp-sass');

var wroot = './Areas/Admin/Content';
var dest = wroot + '/styles';

gulp.task('sass-admin', function () {
    gulp.src('./Areas/Admin/Content/sass/*.scss')
        .pipe(sass())
        .pipe(gulp.dest('./Areas/Admin/Content/styles'));
});

// Watch Files For Changes
gulp.task('watch-admin', function () {
    gulp.watch(['./Areas/Admin/Content/sass/**/*'], ['sass-admin']);
});