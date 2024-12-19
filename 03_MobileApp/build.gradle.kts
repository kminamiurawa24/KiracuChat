buildscript {
    repositories {
        google()
        mavenCentral()
    }
    dependencies {
        classpath(libs.androidGradlePlugin)
        classpath(libs.kotlinGradlePlugin)
        classpath(libs.kotlinx.serialization.json)
    }
}

repositories {
    google() // こちらに移動
    mavenCentral()
}