cmake_minimum_required(VERSION 3.20)

set(CMAKE_C_STANDARD 17)
set(CMAKE_C_STANDARD_REQUIRED ON)

find_path(UTHASH_INCLUDE_DIRS "uthash.h")

add_library(libleetcodec STATIC
        atm.h
        atm.c
        data_structures.h
        interview_solution.h
        interview_solution.c
        recent_counter.h
        solution.h
        solution.c
        utils.h
        utils.c
)

if (UNIX)
    target_link_libraries(libleetcodec PUBLIC m)
endif ()

target_include_directories(libleetcodec PUBLIC ${CMAKE_CURRENT_SOURCE_DIR} PRIVATE ${UTHASH_INCLUDE_DIRS})