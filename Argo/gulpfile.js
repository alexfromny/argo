var gulp = require('gulp'),
    sass = require('gulp-sass'),
    path = require('path'),
    copy = function (source, destination) {
        return gulp.src(source)
            .pipe(gulp.dest(destination));
    };

gulp.task('css', function () {
    gulp.src('./Content/sass/**/*.scss')
        .pipe(sass().on('error', sass.logError))
        .pipe(gulp.dest('./Content/css'));
});

gulp.task('watch:css', function () {
    gulp.watch('./Content/sass/**/*.scss', ['css']);
});

gulp.task('watch', ['watch:css']);
gulp.task('build', ['css']);


gulp.task('default', ['build'], function () {
    gulp.start('watch');
});
