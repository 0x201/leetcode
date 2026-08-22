plugins {
    id("java")
}

group = "org.trickyrat"
version = "1.0-SNAPSHOT"


dependencies {
    testImplementation("org.junit.jupiter:junit-jupiter-api:5.13.4")
}

tasks.test {
    useJUnitPlatform()
}

java {
    toolchain {
        languageVersion = JavaLanguageVersion.of(25)
    }
}